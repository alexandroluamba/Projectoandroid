import random
pala = ['miguel','Python','carro']
random_pal = random.choice(pala)
palavras = random_pal
lista_usuario = []
chances = 7
ganhou = False

while True:
    print(f'Tens {chances} chances')
    for letra in palavras:
        if letra.lower() in lista_usuario:
            print(letra,end=' ')
        else:
            print('_',end=' ')
    print(' ')

    tentativa = input('digite um careter para adivinhar:')
    lista_usuario.append(tentativa.lower())
    if tentativa.lower() not in palavras.lower():
        chances -= 1
    ganhou = True
    for letra in palavras:
        if letra not in lista_usuario:
            ganhou = False





    if chances == 0 :
        print('\033[31m voce perdeu \033[m')
        break

  