$(document).ready(function () {

    // $("#Valor").mask("000,00");

    $('#meuform').validate({

        rules: {
            'Nome': {
                required: true,
                minlength: 3
            },
            'Professor': {
                required: true,
                minlength: 3

            },
            'QtdVagas': {
                required: true

            },
            'Valor': {
                required: true

                //Senha deve ter entre 4 e 15 caracteres
            }
        },
        messages: {
            'Nome': {
                required: 'Digite um nome do curso',
                minlength: 'Por favor, insira pelo menos 3 caracteres'
            },
            'Professor': {
                required: 'Digite o nome do Professor',
                minlength: 'Por favor, insira pelo menos 3 caracteres'

            },
            'QtdVagas': {
                required: 'Digite quantidade de vagas'
            },
            'Valor': {
                required: 'Digite um valor'
            }
        }
    });
});