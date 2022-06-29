using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Helpers
{
    public static class FileHelper
    {
        public static void DeleteFile(IWebHostEnvironment env, string file, params string[] folders)
        {
            string path = Path.Combine(env.WebRootPath);
            foreach (string folder in folders)
            {
                path = Path.Combine(path, folder);
            }
            path = Path.Combine(path, file);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public static void DeleteMultipleFiles(IWebHostEnvironment env, string files, params string[] folders)
        {
            string[] file = files.Split(',');
            for (int i = 0; i < file.Length; i++)
            {
                file[i] = file[i].Trim();

                string path = Path.Combine(env.WebRootPath);
                foreach (string folder in folders)
                {
                    path = Path.Combine(path, folder);
                }
                path = Path.Combine(path, file[i]);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            
        }
    }
}
