IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
Q1_A1 db 1, 2, 3, 4
Q1_A2 db 2, 5, 10, 8
sum dw ?

Q3A_Var1 db 10
Q3A_Var2 db 5
Q3A_Ans db ?
Q3A_Remainder db ?

Q3B_Var1 db 10
Q3B_Var2 db -2
Q3B_Ans db ?
Q3B_Remainder db ?

Q3C_Var1 dw 0FFFFh
Q3C_Var2 dw 0EEEEh
Q3C_Ans dw ?
Q3C_Remainder dw ?
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
; Question 1 - mul
mov al, [Q1_A1]
mov bl, [Q1_A2]
imul bl
add [sum], ax

mov al, [Q1_A1 + 1]
mov bl, [Q1_A2 + 1]
imul bl
add [sum], ax

mov al, [Q1_A1 + 2]
mov bl, [Q1_A2 + 2]
imul bl
add [sum], ax

mov al, [Q1_A1 + 3]
mov bl, [Q1_A2 + 3]
imul bl
add [sum], ax

; Question 2 - div follow
mov ax, 0
mov bx, 0

mov al, 7
mov bl, 2
mov ah, 0
div bl
mov ax, 7
mov dx, 0
mov bx, 2
div bx

; Question 3A - div
mov ax, 0
mov bx, 0

mov al, [Q3A_Var1]
mov bl, [Q3A_Var2]
div bl
mov [Q3A_Ans], al
mov [Q3A_Remainder], ah

; Question 3B - div
mov ax, 0
mov bx, 0

mov al, [Q3B_Var1]
mov bl, [Q3B_Var2]
idiv bl
mov [Q3B_Ans], al
mov [Q3B_Remainder], ah

; Question 3C - div
mov ax, 0
mov bx, 0
mov dx, 0

mov ax, [Q3C_Var1]
mov bx, [Q3C_Var2]
div bx
mov [Q3C_Ans], ax
mov [Q3C_Remainder], dx
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


