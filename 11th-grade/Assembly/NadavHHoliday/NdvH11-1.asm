IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
; --------------------------
CODESEG
		
proc GreaterASCII
	A_Var1 equ [bp + 6]
	A_Var2 equ [bp + 4]

	push bp
	mov bp, sp
	
	mov ax, A_Var1
	cmp ax, A_Var2
	
	pop bp
	ret 4
endp GreaterASCII


proc CheckIfNum
	IfNum equ [bp + 4]
	
	push bp
	mov bp, sp
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9h
	int 21h
	
	mov al, IfNum
	cmp al, 30h
	jnae NotNum
	cmp al, 39h
	ja NotNum
		
	; Prints Y - stands for yes
	mov dl, 'Y'
	mov ah, 2
	int 21h
	jmp CheckEnd
	
NotNum:
	; Prints N - stands for no
	mov dl, 'N'
	mov ah, 2
	int 21h

CheckEnd:
	pop bp
	ret 2
endp CheckIfNum


proc AllNumCalc
	push bp
	mov bp, sp
	
	mov cx, 10
	mov si, 4
CheckNumbers:
	mov al, [bp + si]
	cmp al, 30h
	jnae NotAllNum
	cmp al, 39h
	ja NotAllNum
	add si, 2
	loop CheckNumbers

	mov cx, 10
	mov si, 4
AddNumbers:
	mov al, [bp + si]
	sub al, 30h
	add dl, al
	add si, 2
	loop AddNumbers

NotAllNum:
	pop bp
	ret 20
endp AllNumCalc

start:
	mov ax, @data
	mov ds, ax
; --------------------------
	; A
	mov cx, 2
Input:
	; Get input of single char
	mov ah, 1
	int 21h
	xor ah, ah
	push ax
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	loop Input
		
	call GreaterASCII
	
	
	; B
	; Get input of single char
	mov ah, 1
	int 21h
	push ax
		
	call CheckIfNum
	
	; C
	mov cx, 10
InputNum:
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; Get input of single char
	mov ah, 1
	int 21h
	xor ah, ah
	push ax
	
	loop InputNum
	call AllNumCalc
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


