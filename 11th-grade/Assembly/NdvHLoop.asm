IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
Fib db 10 dup (?)
Input db 5 dup (?)
var1 db 5
var2 db 6
column db ?
row db ?
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
jmp D
; A
A:
	xor ax, ax
	mov cx, 8
	xor di, di
	mov [Fib + di], al ; 0
	inc di
	mov ah, 1
	mov [Fib + di], ah ; 1
	inc di
	jmp Fibonacci
	
	Fibonacci:
		mov dl, ah
		add ah, al
		mov al, dl
		mov [Fib + di], ah
		inc di
		loop Fibonacci
	jmp exit

; B
B:
	mov cx, 5
	mov di, 0
	jmp input_to_array
	
	input_to_array:
		mov ah, 1h
		int 21h
		mov [Input + di], al
		inc di
		loop input_to_array
	jmp exit

; C
C:
	xor ax, ax
	mov cl, [var1]
	multiply:
		add al, [var2]
		loop multiply
	jmp exit

; D
D:
	mov ah, 1
	int 21h
	sub al, '0'
	mov [column], al
	
	mov dl, 0ah
	mov ah, 2h
	int 21h

	mov ah, 1
	int 21h
	sub al, '0'
	mov [row], al
	
	mov dl, 0ah
	mov ah, 2h
	int 21h
	
	mov cl, [row]
	mov bl, [column] 
	
	PrintColumn:
		; Print one char (x)
		mov dl, 'x'
		mov ah, 2h
		int 21h
		
		; Loop to print row
		loop PrintColumn
		
		; Print new line
		mov dl, 0ah
		mov ah, 2h
		int 21h
		
		; Reset row counter
		mov cl, [row]
		
		; Loop to print column
		dec bx
		jnz PrintColumn
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


