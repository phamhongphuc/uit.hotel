﻿using Realms;

namespace uit.ooad.Models
{
    public class Room : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public Floor Floor { get; set; }
        public RoomType RoomType { get; set; }
    }
}
