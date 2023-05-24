﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Teatr_BG.Models.DbModels
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A client. </summary>
    ///
    /// <remarks>   Julia, 20.05.2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Client
    {
        [Key]
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the client. </summary>
        ///
        /// <value> The identifier of the client. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ClientID { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's first name. </summary>
        ///
        /// <value> The name of the first. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string FirstName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's last name. </summary>
        ///
        /// <value> The name of the last. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string LastName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the phone number. </summary>
        ///
        /// <value> The phone number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PhoneNumber { get; set; }

    }
}