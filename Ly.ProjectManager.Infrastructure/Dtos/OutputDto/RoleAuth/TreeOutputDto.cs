﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Infrastructure.Dtos.OutputDto.RoleAuth
{
    public class TreeOutputDto
    {
        public string parentId { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        public int? checkstate { get; set; }
        public bool showcheck { get; set; }
        public bool complete { get; set; }
        public bool isexpand { get; set; }
        public bool hasChildren { get; set; }
        public string img { get; set; }
        public string title { get; set; }
    }
}