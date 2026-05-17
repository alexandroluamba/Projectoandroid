/*fat=1
function fatorial(n){
    for (let c= n;c>1;c--){
       fat *= c
    }
    return fat

}
console.log(fatorial(5))*/
console.log('obeserve:')
function fatora(N){
    if (N == 1){
        return 1
    }else{
        return N * fatora(N-1)
    }
}
console.log(fatora(5))