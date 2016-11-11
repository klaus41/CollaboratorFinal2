using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.EmailManager
{
    public class ThreadManager
    {
        private CollaboratorContext db = new CollaboratorContext();

        private Thread thread;
        private bool done;
        private EmailReader er = new EmailReader();
        EmailWriter ew = new EmailWriter();
        Indexer indexer = new Indexer();
        List<Email> emails;
        FindItemsResults<Item> findResults;
        DateTime searchdate;
        List<Email> tempEmails;

        public void StartEmailThread()
        {
            done = false;
            thread = new Thread(new ThreadStart(DoWork));
            thread.Start();

        }

        private void DoWork()
        {
            while (!done)
            {

                foreach (EmailAccount ea in db.EmailAccounts)
                {
                    tempEmails = new List<Email>();

                    foreach (var email in db.Emails.Where(x => x.Recipiant == ea.EmailAddress))
                    {
                        tempEmails.Add(email);
                    }
                    if (tempEmails.Count() != 0)
                    {
                        var latest = tempEmails.OrderByDescending(m => m.ReceivedDate).FirstOrDefault();
                        searchdate = latest.ReceivedDate.AddSeconds(1);
                        findResults = er.GetNewEmails(ea.EmailAddress, ea.Password, searchdate);
                    }
                    else
                    {
                        if (ea.EmailAddress.Contains("Carsten") || ea.EmailAddress.Contains("carsten") || ea.EmailAddress.Contains("CARSTEN")
                            || ea.EmailAddress.Contains("Henry") || ea.EmailAddress.Contains("henry") || ea.EmailAddress.Contains("HENRY"))
                        {
                            searchdate = new DateTime(2016, 9, 1);
                            findResults = er.GetNewEmails(ea.EmailAddress, ea.Password, searchdate);
                        }
                        else
                        {
                            findResults = er.GetAllEmails(ea.EmailAddress, ea.Password);
                        }
                    }


                    emails = ew.EmailConverter(findResults);
                    if (emails.Count() != 0 && emails != null)
                    {
                        ew.SaveEmails(emails);
                        indexer.IndexNewEmails(emails);
                    }
                    Debug.WriteLine("I just checked for new Email");
                    Debug.WriteLine(emails.Count());
                }
                Thread.Sleep(60000);
            }

        }

        public void Start()
        {
            if (db.Emails.Count() == 0 || db.Emails == null)
            {
                foreach (EmailAccount ea in db.EmailAccounts)
                {
                    findResults = er.GetAllEmails(ea.EmailAddress, ea.Password);
                    emails = ew.EmailConverter(findResults);
                    if (emails.Count() != 0 && emails != null)
                    {
                        ew.SaveEmails(emails);
                        indexer.IndexAllEmails();
                    }
                }
            }
            StartEmailThread();
        }

    }
}