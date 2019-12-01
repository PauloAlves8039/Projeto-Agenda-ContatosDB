/*
 * Arquivo: classe Contato
 * Autor: Paulo Alves
 * Descrição: responsável por conter propriedades da entidade Contato
 * Data: 01/12/2019
*/

using System;

namespace AgendaContatos.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public int Telefone { get; set; }
    }
}
