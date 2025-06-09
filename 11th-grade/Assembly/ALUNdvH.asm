IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
; Q1
Q1_A1 db 4, 5, 6, 7
Q1_A2 db 101, 102, 103, 104
; Q2
var1 db 5
var2 db 10
sum dw 0
; Q3
Q3_A1 db 1, 2, 3, 4, 5
Q3_A2 db 5, 4, 3, 2, 1
Q3_A3 db ?, ?, ?, ?, ?
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
; Question 1
mov al, [byte ptr Q1_A1]
add al, [byte ptr Q1_A1 + 1]
add al, [byte ptr Q1_A1 + 2]
add al, [byte ptr Q1_A1 + 3]

; The program doesn't work with values greater then 100
; because the values flow over the limit.
mov bl, [byte ptr Q1_A2]
add bl, [byte ptr Q1_A2 + 1]
add bl, [byte ptr Q1_A2 + 2]
add bl, [byte ptr Q1_A2 + 3]

mov bx, 0
mov ax, 0
; To solve the problem we use bx instead of bl and cbw
mov al, [Q1_A2]
cbw
add bx, ax
mov al, [Q1_A2 + 1]
cbw
add bx, ax
mov al, [Q1_A2 + 2]
cbw
add bx, ax
mov al, [Q1_A2 + 3]
cbw
add bx, ax

; Question 2
mov ax, 0
mov bx, 0

mov al, [var1]
cbw
add bx, ax
mov al, [var2]
cbw
add bx, ax
mov [sum], bx

; Question 3
mov ax, 0
mov bx, 0

mov ax, [word ptr Q3_A1]
sub ax, [word ptr Q3_A2]
mov [Q3_A3], al

mov ax, [word ptr Q3_A1 + 1]
sub ax, [word ptr Q3_A2 + 1]
mov [Q3_A3 + 1], al

mov ax, [word ptr Q3_A1 + 2]
sub ax, [word ptr Q3_A2 + 2]
mov [Q3_A3 + 2], al

mov ax, [word ptr Q3_A1 + 3]
sub ax, [word ptr Q3_A2 + 3]
mov [Q3_A3 + 3], al

mov ax, [word ptr Q3_A1 + 4]
sub ax, [word ptr Q3_A2 + 4]
mov [Q3_A3 + 4], al
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


