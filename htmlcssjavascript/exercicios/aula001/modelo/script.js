function contar(){
    var ini = document.getElementById('txt1')
    var fim = document.getElementById('txt2')
    var passo = document.getElementById('txt3')

    if (ini.Value.length == 0 || fim.value.length == 0 || passo.value.length == 0){
        window.alert('[Erro] numero invalido')
    }
}