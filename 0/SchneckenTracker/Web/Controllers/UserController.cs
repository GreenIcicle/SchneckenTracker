using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace Schnecke.Tracker.Controllers
{
    public class UserController : Controller
    {
        private static OpenIdRelyingParty openid = new OpenIdRelyingParty();

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/");
        }

        public ActionResult Login()
        {
            // Stage 1: display login form to user
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Authenticate(string openid_identifier)
        {
            var response = openid.GetResponse();

           



            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(openid_identifier, out id))
                {
                    try
                    {
                        var request = openid.CreateRequest(openid_identifier);
                        request.AddExtension(new ClaimsRequest
                        {                             
                            Email = DemandLevel.Request
                        });
                        return request.RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ViewData["Message"] = ex.Message;
                        return View("Login");
                    }
                }
                else
                {
                    ViewData["Message"] = "Invalid identifier";
                    return View("Login");
                }
            }
            else
            {
                // Stage 3: OpenID Provider sending assertion response
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:

                        string userName = response.ClaimedIdentifier;
                        
                        var claimsResponse = response.GetExtension<ClaimsResponse>();
                        if(claimsResponse != null)
                        {
                            userName = claimsResponse.Email;
                        }

                        FormsAuthentication.SetAuthCookie(userName, false);  
                        return RedirectToAction("Home", "Home");
   
                    case AuthenticationStatus.Canceled:
                        ViewData["Message"] = "Canceled at provider";
                        return View("Login");

                    case AuthenticationStatus.Failed:
                        ViewData["Message"] = response.Exception.Message;
                        return View("Login");
                }
            }
            return new EmptyResult();
        }
    }
}

