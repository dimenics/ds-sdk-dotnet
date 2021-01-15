﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dime.Scheduler.Sdk.Samples
{
    public class ImportRequestSample
    {
        public async Task Execute()
        {
            try
            {
                string uri = "http://localhost:53006/";
                DimeSchedulerClient client = new(uri);
                await client.Authenticate("hendrik.bulens@gmail.com", "Password123");

                ImportRequest importRequest = new(
                    "mboc_upsertExchangeAppointment",
                    new List<string>
                    {
                        "AppointmentId",
                        "Start",
                        "End",
                        "Subject",
                        "Body",
                        "Importance",
                        "ResourceEmail"
                    }.ToArray(),
                    new List<string>
                    {
                        "0",
                        new DateTime(2021,1,15, 10, 0,0).ToString("s") + "",
                        new DateTime(2021,1,15, 12, 0,0).ToString("s") + "",
                        "Hello world",
                        "Lorem ipsum",
                        "0",
                        "hendrik.bulens@dimenics.com"
                    }.ToArray())
                {
                    Uri = uri,
                    AuthenticationToken = client.AuthenticationToken
                };

                ImportEndpointService importEndpoint = client.CreateEndpointService<ImportEndpointService>();
                await importEndpoint.Create(importRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
