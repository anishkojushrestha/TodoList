﻿namespace TodoList.Dto
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? lastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
