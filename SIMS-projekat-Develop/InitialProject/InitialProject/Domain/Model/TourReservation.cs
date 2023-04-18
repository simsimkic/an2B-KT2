﻿using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace InitialProject.Domain.Model
{
    public class TourReservation : ISerializable
    {
        public int Id { get; set; }
        public int IdTour { get; set; }
        public string TourName { get; set; }
        public int IdUser { get; set; }
        public int GuestNum { get; set; }
        public int IdLocation { get; set; }
        public int FreeSetsNum { get; set; }
        public int IdTourPoint { get; set; }
        public string UserName { get; set; }
        public bool UsedVoucher { get; set; }

        public TourReservation() { }

        public TourReservation(int idTour, string TourName, int idUser, int GuestNum, int freeSetsNum, int idTourPoint, string userName)
        {
            IdTour = idTour;
            this.TourName = TourName;
            IdUser = idUser;
            this.GuestNum = GuestNum;
            FreeSetsNum = freeSetsNum;
            IdTourPoint = idTourPoint;
            UserName = userName;
            UsedVoucher = false;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                IdTour.ToString(),
                TourName,
                IdUser.ToString(),
                GuestNum.ToString(),
                FreeSetsNum.ToString(),
                IdTourPoint.ToString(),
                UserName,
                UsedVoucher.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            IdTour = int.Parse(values[1]);
            TourName = values[2];
            IdUser = int.Parse(values[3]);
            GuestNum = int.Parse(values[4]);
            FreeSetsNum = int.Parse(values[5]);
            IdTourPoint = int.Parse(values[6]);
            UserName = values[7];
            UsedVoucher = bool.Parse(values[8]);
        }
    }
}
