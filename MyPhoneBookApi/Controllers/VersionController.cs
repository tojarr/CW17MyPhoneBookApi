﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyPhoneBookApi.Controllers
{
    public class VersionController : ApiController
    {
        //GET: api/Version
        public string GetLastVersion()
        {
            return "2";
        }
    }
}
