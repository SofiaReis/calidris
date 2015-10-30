﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;


namespace FirstREST.Controllers
{
    public class EncomendaController : ApiController
    {
        //
        // GET: /Encomenda/

        public IEnumerable<Lib_Primavera.Model.Encomenda> Get()
        {
            return Lib_Primavera.PriIntegration.EncomendasPendentes_List();
        }


        // GET api/encomenda/5    
        /*public Lib_Primavera.Model.Encomenda Get(string id)
        {
            Lib_Primavera.Model.Encomenda encomenda = Lib_Primavera.PriIntegration.Encomenda_Get(id);
            if (encomenda == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));


            }
            else
            {
                return encomenda;
            }
        }*/


        /*public HttpResponseMessage Post(Lib_Primavera.Model.Encomenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();
            erro = Lib_Primavera.PriIntegration.Encomendas_New(dv);

            if (erro.Erro == 0)
            {
                var response = Request.CreateResponse(
                   HttpStatusCode.Created, dv.CDU_Ref);
                string uri = Url.Link("DefaultApi", new { DocId = dv.CDU_Ref });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }*/


        public HttpResponseMessage Put(String Ref, String RefArt)
        {

            Boolean erro;

            erro = Lib_Primavera.PriIntegration.Update_Encomenda(Ref, RefArt);
            if (!erro)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Encomenda pronta para Putaway");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Encomenda inexistente ou Ainda existem artigos pendentes");
            }
        }



        /*public HttpResponseMessage Delete(string id)
        {


            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();

            try
            {

                erro = Lib_Primavera.PriIntegration.DelCliente(id);

                if (erro.Erro == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, erro.Descricao);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro.Descricao);
                }

            }

            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro.Descricao);

            }

        }*/
    }
}
