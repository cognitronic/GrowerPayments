using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core;
using Alpine.Core.Domain.User;
using Alpine.Core.Domain.Account;
using Alpine.Core.Domain.Grower;
using Alpine.Infrastructure.Session;
using Alpine.Infrastructure.Domain;
using StructureMap;
using System.Web;

namespace Alpine.Web.Security
{
    [Serializable]
    public class WebSecurityContext : IAlpineSecurityContext
    {
        #region ISecurityContext Members

        public bool IsAuthenticated
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_IsAuthenticated] != null)
                {
                    return (bool)SessionManager.Current[ResourceStrings.Session_IsAuthenticated];
                }
                return false;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_IsAuthenticated] = value;
            }
        }

        public IBaseUser CurrentUser
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentUser] != null)
                {
                    return (IBaseUser)SessionManager.Current[ResourceStrings.Session_CurrentUser];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentUser] = value;
            }
        }

        public IAccount CurrentAccount
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentAccount] != null)
                {
                    return (IAccount)SessionManager.Current[ResourceStrings.Session_CurrentAccount];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentAccount] = value;
            }
        }

        public IGrower CurrentGrower
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentGrower] != null)
                {
                    return (IGrower)SessionManager.Current[ResourceStrings.Session_CurrentGrower];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentGrower] = value;
            }
        }

        public string BaseURL
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
                else
                {
                    SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = value;
            }
        }

        public string CurrentCropYear
        {
            get
            {
                if (DateTime.Today.Month < 9)
                    return DateTime.Today.AddYears(-1).Year.ToString();
                return DateTime.Today.Year.ToString();
            }
        }

        public string CurrentGrowerID
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentGrowerID] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentGrowerID].ToString();
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentGrowerID] = value;
            }
        }

        public int CurrentAccessLevel
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel] != null)
                {
                    return (int)SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel];
                }
                return 0;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel] = value;
            }
        }
        #endregion

        #region ISecurityContext Members


        public ISystemObject CurrentSystemObject
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
