﻿using System.Runtime.Serialization;

namespace TitleViewSearch.Models
{
    [DataContract]
    public class Genre
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [DataMember(Name = "name")]
        public string Name { get; private set; }
    }
}