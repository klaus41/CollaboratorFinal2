﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model.Model
{
    [DataContract(IsReference = true)]
    [Table("SearchCriteria")]
    public class SearchCriteria
    {
        public SearchCriteria()
        {
            this.Themes = new HashSet<Theme>();
            this.Emails = new HashSet<Email>();
        }
        [Key]
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Criteria { get; set; }
        [DataMember]
        public virtual ICollection<Theme> Themes { get; set; }
        [DataMember]
        public virtual ICollection<Email> Emails { get; set; }
    }
}