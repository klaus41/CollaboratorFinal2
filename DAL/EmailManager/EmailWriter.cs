using DAL.Context;
using Microsoft.Exchange.WebServices.Data;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace DAL.EmailManager
{
    public class EmailWriter
    {
        private CollaboratorContext db = new CollaboratorContext();
        private List<Email> emails;
        private Email email;
        private EmailMessage message;

        public List<Email> EmailConverter(FindItemsResults<Item> findResults)
        {
            PropertySet itempropertyset = new PropertySet(BasePropertySet.FirstClassProperties);
            itempropertyset.RequestedBodyType = BodyType.Text;

            Random r = new Random();
            emails = new List<Email>();
            foreach (var item in findResults)
            {
                message = (EmailMessage)item;
                item.Load(itempropertyset);

                email = new Email();
                email.BodyText = item.Body;

                email.Recipiant = message.ReceivedBy != null ? message.ReceivedBy.Address : "Modtager Untilgængelig";
                email.Sender = message.Sender != null ? message.Sender.Address : "Afsender Untilgængelig";
                email.Subject = item.Subject != null ? item.Subject : "Emne utilgængeligt";

                if (item.DateTimeReceived != null && item.DateTimeReceived > new DateTime(1950, 1, 1))
                {
                    email.ReceivedDate = item.DateTimeReceived;
                }
                else
                {
                    email.ReceivedDate = new DateTime(2000, 1, 1);
                }
                

                emails.Add(email);
            }

            return emails;
        }

        public void SaveEmails(List<Email> emails)
        {
            using (var ctx = new CollaboratorContext())
            {
                if (emails.Count() != 0 && emails != null)
                {
                    foreach (var email in emails)
                    {
                        ctx.Emails.Add(email);
                    }
                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }

    }
}
