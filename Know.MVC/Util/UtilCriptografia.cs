﻿namespace Know.MVC.Util
{
    public class UtilCriptografia
    {
        #region Propriedades

        Criptografia.Criptografia crip;

        #endregion

        #region Public

        public  string Criptografar(string generico)
        {
            crip = new Criptografia.Criptografia();

            generico = crip.Criptografar(generico);

            return generico;
        }

        public string Descriptografar(string generico)
        {
            crip = new Criptografia.Criptografia();

            generico = crip.Descriptografar(generico);

            return generico;
        }

        #endregion
    }
}