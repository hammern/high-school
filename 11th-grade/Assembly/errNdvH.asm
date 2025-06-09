IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
; Your variables here
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
	mov ax, 0Bh
	mov 0Bh, ax
	mov [ax], 10h
	mov ax, [bx]
	mov [bx], [bx]
	mov cx, si
	mov cx, [si]
	mov [cx], si
	mov [bx + si], cx
	mov ax, [bx + dx]
	mov [bx + di + 2], dx
	mov [bx + si + di], ax
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


