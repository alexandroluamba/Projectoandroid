function contar(){
    let res = document.getElementById('res')
    let ini = document.getElementById('txt1')
   
    let fim = document.getElementById('txt2')
    let passo = document.getElementById('txt3')
    if (ini.value.length == 0 || fim.value.length == 0 || passo.value.length == 0 ){
        window.alert('[Erro] numero invalido')
        res.innerHTML = `Ipossivel  contar`
    }
    else {
        res.innerHTML =`Contando:`
        var i = Number(ini.value)
        var f = Number(fim.value)
        var p = Number(passo.value)
        if (i < f){
             for(let c = i; c <= f;c += p){
            res.innerHTML += `${c} \u{1F449}`
           }
       
       }else{
         for(let c = i; c >= f; c -= p){
            res.innerHTML += `${c} \u{1F449}`
             }
       
        }
        
        res.innerHTML +=' \u{1F3C1}'
    }
    
}