﻿namespace WebapiProject.Models
{
    public class UserOrderDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public int OrderedQuantity { get; set; }
    }
}