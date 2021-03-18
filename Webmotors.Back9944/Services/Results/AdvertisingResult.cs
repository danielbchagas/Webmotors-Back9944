using System.Collections.Generic;

namespace Webmotors.Back9944.Services.Results
{
    public class AdvertisingResult
    {
        public int AffectedRows { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
