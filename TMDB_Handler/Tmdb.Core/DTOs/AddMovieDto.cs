﻿namespace Tmdb.Core.DTOs
{
    public class AddMovieDto
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string ProfileName { get; set; } = string.Empty;
    }
}
