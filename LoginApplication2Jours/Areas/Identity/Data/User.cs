﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LoginApplication2Jours.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    [PersonalData]
    [Required]
    [Column(TypeName ="nvarchar(100)")]
    public required string FirstName  { get; set; } 

    [PersonalData]
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public  required string LastName { get; set; }
}

