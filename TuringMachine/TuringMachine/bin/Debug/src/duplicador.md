# Adds 1 to a binary number.
input: '  c                                            '
blank: ' '
start state: q13
table:
  # scan to the rightmost digit
  q13:
    ' ': {write: ' ', R: q13}
    a: {write: a, R: q14}
    b: {write: b, R: q15}
    c: {write: c, R: q16}
  q14: 
    ' ': {write: a, R: q10}
    a: {write: a, L: q0}
    b: {write: b, L: q0}
    c: {write: c, L: q0}
  q15:
    ' ': {write: b, R: q10}
    a: {write: a, L: q0}
    b: {write: b, L: q0}
    c: {write: c, L: q0}    
  q16: 
    ' ': {write: c, R: q10}
    a: {write: a, L: q0}
    b: {write: b, L: q0}
    c: {write: c, L: q0}
  q0:
    ' ': {write: ' ', R: q0}
    a: {write: A, R: q1}
    b: {write: B, R: q1}
    c: {write: C, R: q1}
    0: {write: 0, R: q4}
  q1:
    a: {write: a, R: q1}
    b: {write: b, R: q1}
    c: {write: c, R: q1}
    0: {write: 0, R: q1}
    ' ': {write: 0, L: q2}
  q2:
    a: {write: a, L: q2}
    b: {write: b, L: q2}
    c: {write: c, L: q2}
    0: {write: 0, L: q2}
    A: {write: a, R: q0}
    B: {write: b, R: q0}
    C: {write: c, R: q0}
  q4:
    0: {write: 0, L: q4}
    a: {write: a, L: q4}
    b: {write: b, L: q4}
    c: {write: c, L: q4}
    ' ': {write: ' ', R: q5}
    A: {write: A, R: q5}
    B: {write: B, R: q5}
    C: {write: C, R: q5}
  q5:
    a: {write: A, R: q6}
    b: {write: B, R: q7}
    c: {write: C, R: q8}
  # Substitutes A's
  q6:
    a: {write: a, R: q6}
    b: {write: b, R: q6}
    c: {write: c, R: q6}
    0: {write: a, R: q12}
    ' ': {write: ' ', L: q9}
    
  # Substitutes B's
  q7:
    a: {write: a, R: q7}
    b: {write: b, R: q7}
    c: {write: c, R: q7}
    0: {write: b, R: q12}
    ' ': {write: ' ', L: q9}
  # Substitutes C's
  q8:
    a: {write: a, R: q8}
    b: {write: b, R: q8}
    c: {write: c, R: q8}
    0: {write: c, R: q12}
    ' ': {write: ' ', L: q9}

  q9:
    a: {write: a, L: q9}
    b: {write: b, L: q9}
    c: {write: c, L: q9}
    ' ': {write: ' ', L: q10}
    
  q11:
    a: {write: a, L: q11}
    b: {write: b, L: q11}
    c: {write: c, L: q11}
    A: {write: a, L: q11}
    B: {write: b, L: q11}
    C: {write: c, L: q11}
    ' ': {write: ' ', R: q10}
  q10:
  
  q12:
    0: {write: 0, L: q12}
    a: {write: a, L: q12}
    b: {write: b, L: q12}
    c: {write: c, L: q12}
    ' ': {write: ' ', L: q11}
    A: {write: A, R: q5}
    B: {write: B, R: q5}
    C: {write: C, R: q5}