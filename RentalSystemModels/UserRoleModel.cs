﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystemModels
{
   public class UserRoleModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserLoginModel> UserLogins { get; set; }
    }
}
