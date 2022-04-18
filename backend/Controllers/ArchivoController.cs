using Entity;
using Logical;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivoController : Controller
    {

        public Dictionary<string, string> mime = new Dictionary<string, string>();

        public ArchivoController()
        {
            //mime.add("txt", "data:text/plain;base64,");
            //mime.add("doc", "data:application/msword;base64,");
            //mime.add("docx", "data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,");
            //mime.add("gif", "data:image/gif;base64,");
            //mime.add("ico", "data:image/vnd.microsoft.icon;base64,");
            //mime.add("json", "data:application/json;base64,");
            //mime.add("png", "data:image/png;base64,");
            //mime.add("jpg", "data:image/jpeg;base64,");
            //mime.add("jpeg", "data:image/jpeg;base64,");
            //mime.add("pdf", "data:application/pdf;base64,");
            //mime.add("ppt", "data:application/vnd.ms-powerpoint;base64,");
            //mime.add("pptx", "data:application/vnd.openxmlformats-officedocument.presentationml.presentation;base64,");
            //mime.add("rar", "data:application/vnd.rar;base64,");
            //mime.add("tar", "data:application/x-tar;base64,");
            //mime.add("xls", "data:application/vnd.ms-excel;base64,");
            //mime.add("xlsx", "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,");
            //mime.add("zip", "data:application/zip;base64,");
            //mime.add("7z", "data:application/x-7z-compressed;base64,");
        }


        [HttpPost]
        public bool subirArchivo(List<ArchivoRequest> req)
        {
            try
            {
                foreach (ArchivoRequest request in req)
                {
                    byte[] bytes = Convert.FromBase64String(request.imagensrc);
                    larchivo larchivo = new larchivo();
                    larchivo.guardarArchivo(bytes, request.nombre + "." + request.extension);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        [HttpPost("a")]
        public ArchivoRequest Listararchivo(ArchivoRequest req)
        {
            try
            {
                lpublicaciones l =  new lpublicaciones();
                Console.WriteLine(req.nombre);
                return l.listarimagenes(req);
            }
            catch (Exception ex)
            {
                throw ex;
            }
   
        }






    }
}
