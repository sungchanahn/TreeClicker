# TreeClicker

클릭해서 나무를 키우는 게임
(나무를 키워 미지의 행성을 테라포밍하는 게임을 목표로 개발)

![2](https://github.com/user-attachments/assets/9ae36a95-676d-4802-8eea-dfab259a8fed)
![1](https://github.com/user-attachments/assets/c8038359-a509-47fe-a4a6-7a29965bf11c)

나무는 크게 씨앗 - 새싹 - 묘목 - 성목 - 고목의 단계로 나눠서 각 단계별로 성장 목표치를 가지고 있고   
해당 목표치에 도달하면 다음 단계의 나무를 다시 키우는 방식의 게임

### 구현 기능   
- **클릭 이벤트 처리**
Player Input - Invoke Unity Event, event Action으로 클릭시 이벤트에 등록된 메서드 호출   
클릭 시 나무의 성장도가 오르고, 랜덤으로 골드를 획득   

- **자동 클릭 기능**
Coroutine 활용   
AutoClick 버튼으로 자동 클릭 활성화. 지속 시간이 끝나면 재사용 대기시간이 지난 후 버튼 활성화   

- **점수 시스템**    
클릭으로 얻은 성장도 및 골드 반영   
성장도를 모두 채우면 다음 성장 단계의 나무 프리팹으로 변경   


---
