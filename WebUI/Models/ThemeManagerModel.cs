using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ThemeManagerModel
    {
        public IEnumerable<Theme> themes;
        public IEnumerable<SearchCriteria> searchCriterias; 
    }
}