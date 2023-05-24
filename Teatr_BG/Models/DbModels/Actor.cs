﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Teatr_BG.Models.DbModels
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// An actor.
    /// </summary>
    ///
    /// <remarks>   Julia, 20.05.2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Actor
    {
        [Key]
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the actor. </summary>
        ///
        /// <value> The identifier of the actor. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ActorID { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The first name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string FName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The last name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string LName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the bio. </summary>
        ///
        /// <value> The bio. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Bio { get; set; }
    }
}