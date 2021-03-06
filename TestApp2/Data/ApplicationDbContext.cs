﻿using ElCamino.AspNetCore.Identity.AzureTable;
using ElCamino.AspNetCore.Identity.AzureTable.Model;

namespace TestApp2.Data
{
    public class ApplicationDbContext : IdentityCloudContext
    {
        public ApplicationDbContext()
            : base()
        {
        }

        public ApplicationDbContext(IdentityConfiguration config) : base(config) { }
    }
}
