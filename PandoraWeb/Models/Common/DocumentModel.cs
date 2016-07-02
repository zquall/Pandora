using System.Collections.Generic;
using PandoraObjects.Common;

namespace PandoraWeb.Models.Common
{
    public class DocumentModel
    {
        public DocumentModel()
        {
            Customers = new KeyValueObject[0];
            DocumentDetails = new DocumentGridViewModel[0];
        }
        
        // ------------------------
        public IEnumerable<DocumentGridViewModel> DocumentDetails { get; set; }
        public IEnumerable<KeyValueObject> Customers { get; set; }
        
    }
}