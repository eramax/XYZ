﻿using System.Diagnostics;
using System.Security.Policy;
using System.Threading.Tasks;
using log4net;
using SMSIntegration.Gawlay;
using Twilio;

namespace SMSIntegration.Twilio
{
   public class Twilio
    {
        public static Task SendAsync(string destination, string body)
        {
            // Twilio Begin
            var twilio = new TwilioRestClient(
              Keys.SMSAccountIdentification,
              Keys.SMSAccountPassword);
            LogManager.GetLogger(typeof(Twilio)).Info("Twilio request =>"+     Keys.SMSAccountFrom+","+
              destination+","+ body);
            var result = twilio.SendMessage(
              Keys.SMSAccountFrom,
              destination, body
            );
            // Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
            LogManager.GetLogger(typeof(Twilio)).Info("Twilio response status =>"+ result.Status
            );
            Trace.TraceInformation(result.Status);
            //Twilio doesn't currently have an async API, so return success.
            return Task.FromResult(0);
            // Twilio End

        }

    }
}
