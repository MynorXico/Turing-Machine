# Adds 1 to a binary number.
input: '    111m11=                                            '
blank: ' '
start state: q8
table:
  # scan to the rightmost digit
  q8:
    ' ': {write: ' ', R: q8}
    m: {write: m, R: q7}
    1: {write: 1, R: q9}
    
  q9:
    m: {write: m, L: q0}
    1: {write: 1, L: q0}
  q0:
    ' ': {write: ' ', R: q0}
    1: {write: U, R: q1}
    m: {write: m, R: q3}
  # Agrega un 1 al final
  q1:
    1: {write: 1, R: q1}
    m: {write: m, R: q1}
    =: {write: =, R: q1}
    ' ': {write: 1, L: q2}
  # Regresa a buscar el siguiente uno a copiar
  q2:
    1: {write: 1, L: q2}
    m: {write: m, L: q2}
    =: {write: =, L: q2}
    U: {write: 1, R: q0}
  # Comienza a restar
  q3:
    1: {write: U, R: q4}
    =: {write: =, R: q7}
  # Elimina el último 1
  q4:
    1: {write: 1, R: q4}
    =: {write: =, R: q4}
    ' ': {write: ' ', L: q5}
  # Elimina el 1
  q5:
    1: {write: ' ', L: q6}
    
  # Busca el siguiente uno a eliminar
  q6:
    1: {write: 1, L: q6}
    U: {write: 1, R: q3}
    =: {write: =, L: q6}
  q7:
    