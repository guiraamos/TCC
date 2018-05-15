﻿using System;
using System.IO;

namespace MsAuthenticateService.AuthenticationDB
{
    public class UserDAO
    {

        private static StreamReader OpenDB()
        {
            FileStream file = new FileStream("users.txt", FileMode.Open);
            try
            {
                StreamReader sr = new StreamReader(file);
                return sr;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static string GetUserByUsername(string username)
        {
            StreamReader sr = OpenDB();
            if (sr != null)
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string[] splitedLine = line.Split(';');
                    if (splitedLine[0] == username)
                    {
                        return line;
                    }
                }
            }
            return null;
        }
    }
}

