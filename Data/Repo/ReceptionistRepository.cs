using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Data.Repo
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly DataContext dc;

        public ReceptionistRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public Task<bool> CreateRegistrationRequestAsync(RegistrationRequest request)
        {
            try
            {
                dc.RegistrationRequests.Add(request);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public async Task<IEnumerable<RegistrationRequest>> GetAllRequestsAsync()
        {
            var requests = await dc.RegistrationRequests.ToListAsync();
            return requests;
        }

        public async Task<bool> ApproveRegistrationRequestAsync(int requestId)
        {
            var request = await dc.RegistrationRequests.FindAsync(requestId);

            if (request != null)
            {
                try
                {
                    if(request.Role == "trainer") 
                    {
                        var newUser = new TrainerUser
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            BirthDate = request.BirthDate,
                            UserName = request.UserName,
                            Email = request.Email,
                            Role = request.Role,
                            PhoneNumber = request.PhoneNumber,
                            Password = request.Password,
                            RegistrationDate = DateTime.Now
                        };

                        // Dodaj novog korisnika u odgovarajući DbSet
                        dc.Trainers.Add((TrainerUser)newUser);

                        dc.RegistrationRequests.Remove(request);

                        return true;
                    }
                    if (request.Role == "member")
                    {
                        var newUser = new Member
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            BirthDate = request.BirthDate,
                            UserName = request.UserName,
                            Email = request.Email,
                            Role = request.Role,
                            PhoneNumber = request.PhoneNumber,
                            Password = request.Password,
                            RegistrationDate = DateTime.Now
                        };

                        // Dodaj novog korisnika u odgovarajući DbSet
                        dc.Members.Add((Member)newUser);

                        dc.RegistrationRequests.Remove(request);

                        return true;
                    }

                    if (request.Role == "seller")
                    {
                        var newUser = new Seller
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            BirthDate = request.BirthDate,
                            UserName = request.UserName,
                            Email = request.Email,
                            Role = request.Role,
                            PhoneNumber = request.PhoneNumber,
                            Password = request.Password,
                            RegistrationDate = DateTime.Now
                        };

                        // Dodaj novog korisnika u odgovarajući DbSet
                        dc.Sellers.Add((Seller)newUser);

                        dc.RegistrationRequests.Remove(request);

                        return true;
                    }

                    if (request.Role == "sponsor")
                    {
                        var newUser = new Sponsor
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            BirthDate = request.BirthDate,
                            UserName = request.UserName,
                            Email = request.Email,
                            Role = request.Role,
                            PhoneNumber = request.PhoneNumber,
                            Password = request.Password,
                            RegistrationDate = DateTime.Now
                        };

                        // Dodaj novog korisnika u odgovarajući DbSet
                        dc.Sponsors.Add((Sponsor)newUser);

                        dc.RegistrationRequests.Remove(request);

                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while saving changes: {ex}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException}");
                    }
                }
            }

            return false;
        }



        public async Task<bool> DeleteRequestAsync(int requestId)
        {
            try
            {
                var request = await dc.RegistrationRequests.FindAsync(requestId);

                if (request != null)
                {
                    dc.RegistrationRequests.Remove(request);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
