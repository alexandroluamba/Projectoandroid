let num = document.querySelector("input#fnum")

let res = document.querySelector("div#res")
let vetor = []

function isNumero(n){
    if (Number(n) >= 1 && Number(n) <= 100){
        return true
    }else{
       return false 
    }

}
function inlista(n,l){
    if(l.indexOf(Number(n)) != -1){
        return true
    }else{
        return false
    }
}


function adicionar(){
    if (isNumero(num.value) && !inlista(num.value, vetor)){
        vetor.push(Number(num.value))
        let item = document.createElement('option')
        item.text = `valor ${num.value} adicionado`
        document.querySelector("select#flista").append(item)

    }else{
        window.alert('Valor invalido ou já esta na lista.')
    }
    num.value = ''
    num.focus()
}


function finalizar(){
    if (vetor.length == 0){
        window.alert(' Adicione um valor antes de finalizar')
    }else{
        let tot = vetor.length
        let maior = vetor[0]
        let menor = vetor[0]
        let media = 0
        let soma = 0
        for (let pos in vetor){
            soma += vetor[pos]
            
            if (vetor[pos] > maior)
                maior = vetor[pos]
            if (vetor[pos] < menor)
                menor = vetor[pos]

            

            
        }
        media = soma/tot
        res.innerHTML = ''
        res.innerHTML += `<p> Ao todo temos  ${tot}cadastrados <p/>`
        res.innerHTML += `<p> O maior numero cadastrado  ${maior}<p/><br><br>O menor cadastrado  ${menor} <p/>`
         res.innerHTML += `<p> A soma de todos os numeros cadastrdos é de ${soma} .<br><br> A media é de  ${media}.<p/>`
       
    }

}