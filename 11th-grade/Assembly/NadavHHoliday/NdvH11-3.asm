IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
msg db "Enter a digit:$"
IncorrectMsg db "Wrong input$"
RandomMsg db "I like to write assembly code$"
MyName db "Nadav$"
; --------------------------
CODESEG
	
proc EnterDigit 
	mov dx, offset msg
	mov ah, 9
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; Get input of single char
	mov ah, 1
	int 21h
	
	ret
endp EnterDigit


proc EnterDigitB
	mov dx, offset msg
	mov ah, 9
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; Get input of single char
	mov ah, 1
	int 21h
	
	cmp al, 30h
	jnae NotNum
	cmp al, 39h
	ja NotNum
	jmp EndCheck

NotNum:
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	mov dx, offset IncorrectMsg
	mov ah, 9
	int 21h
	
EndCheck:
	ret
endp EnterDigitB


proc PrintMsgAndName
	mov dx, offset RandomMsg
	mov ah, 9
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	mov dx, offset MyName
	mov ah, 9
	int 21h
	
	ret
endp PrintMsgAndName

start:
	mov ax, @data
	mov ds, ax
; --------------------------
	; A
	call EnterDigit
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; B
	call EnterDigitB
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	; C
	call PrintMsgAndName
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


