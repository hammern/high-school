IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
CorrectMsg db "Correct!$"
WrongMsg db "Wrong password$"
FinalMsg db "No more tries$"
Input db 5 dup(?)
; --------------------------
CODESEG

proc Password
	mov cx, 5
	mov bx, 3 ; Number of tries
	xor si, si

InputPassword:
	mov ah, 1
	int 21h
	
	mov [Input + si], al
	inc si
	
	mov dl, 8h
	mov ah, 2
	int 21h
	
	mov dl, '*'
	mov ah, 2
	int 21h
	
	loop InputPassword
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h

	mov cx, 5
	xor si, si
	mov al, 31h

CheckPassword:
	cmp [Input + si], al
	jne IncorrectPassword
	inc al
	inc si
	
	loop CheckPassword
	
	mov dx, offset CorrectMsg
	mov ah, 9
	int 21h
	
	jmp EndCheck
	
IncorrectPassword:
	mov dx, offset WrongMsg
	mov ah, 9
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	dec bx
	xor si, si
	mov cx, 5
	cmp bx, 0
	ja InputPassword
	
	mov dx, offset FinalMsg
	mov ah, 9
	int 21h

EndCheck:
	ret
endp Password


start:
	mov ax, @data
	mov ds, ax
; --------------------------
	call Password
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


