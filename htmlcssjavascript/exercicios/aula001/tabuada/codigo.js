function gerar(){
    let numero = document.getElementById('numero')
    let tab = document.getElementById('seltab')
    if (numero.value.length == 0){
        window.alert('[erro] numero invalido')
    }else{
        let num = Number(numero.value)
        let cont = 1
        tab.innerHTML = ''
        while (cont <= 12){
            let item = document.createElement('option')
            item.text = `${num} x ${cont} = ${num*cont}`
            item.value = `tab ${cont}`
            tab.appendChild(item)
            cont++
        }
    }
}