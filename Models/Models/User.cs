﻿using ModelsLibrary.Enums;

namespace ModelsLibrary.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
