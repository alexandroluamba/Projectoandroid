var data = new Date()
var ag = data.getUTCDay()

//var idade = 10
//if (idade <16){
//    console.log('nao vota')    
//}else if (idade < 18 || idade >= 65){
    
 //   console.log('voto opcinal')
//}else{
 //   console.log('voto obrigatorio')
//}
console.log(ag)
switch(ag){
    case 0:
        console.log('Domingo')
        break
    case 1:
        console.log('segumda-feira')
        break
    case 2:
        console.log('terça-feira')
        break
    case 3:
        console.log('quarta-feira')
        break
    case 4:
        console.log('quinta-feira')
        break
    case 5:
        console.log('sexta-feira')
        break
    case 6:
        console.log('sabado')
        break

    
}