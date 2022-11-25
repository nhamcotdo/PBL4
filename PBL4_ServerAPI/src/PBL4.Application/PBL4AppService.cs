using System;
using System.Collections.Generic;
using System.Text;
using PBL4.Localization;
using Volo.Abp.Application.Services;

namespace PBL4
{
    /* Inherit your application services from this class.
     */
    public abstract class PBL4AppService : ApplicationService
    {
        protected PBL4AppService()
        {
            LocalizationResource = typeof(PBL4Resource);
        }
    }
}
