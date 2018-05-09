# Adds 1 to a binary number.
input: '1111+1111='
blank: ' '
start state: q0
table:
  # scan to the rightmost digit
  q0:
    1: {write: U, R: q1}
    +: {write: +, R: q0}
    =: {write: =, R: q3}
  # writes 1 at the end of the tape
  q1:
    1: {write: 1, R: q1}
    +: {write: +, R: q1}
    =: {write: =, R: q1}
    ' ': {write: 1, L: q2}
  # looks for an U
  q2:
    =: {write: =, L: q2}
    1: {write: 1, L: q2}
    +: {write: +, L: q2}
    U: {write: 1, R: q0}
    
  q3:
  