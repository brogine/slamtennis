﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlamWeb
{
    public partial class Sesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}