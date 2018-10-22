using System.Web;

namespace DidoStore.Areas.Admin.Code
{
    public class SessionHelper
    {
        public static void setSession(UserSession userSession)
        {
            HttpContext.Current.Session["loginSession"] = userSession; 
        }

        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if(session == null)
            {
                return null;
            }
            else
            {
                return session as UserSession;
            }
        }
    }
}