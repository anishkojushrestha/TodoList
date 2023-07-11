﻿using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoItems
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
