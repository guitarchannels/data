﻿using System;

namespace Core.Entities
{
    public class SuggestionID
    {
        public string ChannelID { get; set; }
        public string UserID { get; set; }
    }

    public class Suggestion
    {
        public SuggestionID ID { get; set; }
        public DateTime When { get; set; }
    }
}