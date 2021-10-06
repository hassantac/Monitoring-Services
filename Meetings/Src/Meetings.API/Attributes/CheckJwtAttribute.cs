﻿using Meetings.API.Filters;
using Meetings.Common.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Linq;

namespace Meetings.API.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CheckJwtAttribute : Attribute, IFilterFactory
    {
        #region Private Fields

        #endregion


        #region Private Methods

        #endregion


        #region Constructors

        #endregion


        #region Properties

        public AccountType[] Allows { get; set; }

        public bool IsReusable => false;

        #endregion


        #region Fields

        #endregion


        #region Methods
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            try
            {
                CheckJwtFilter filter = (CheckJwtFilter)serviceProvider.GetService(typeof(CheckJwtFilter));

                if (Allows != null)
                {
                    filter.Allows = Allows.ToList();
                }

                return filter;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion
    }
}
