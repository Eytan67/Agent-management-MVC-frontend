namespace Agent_management_MVC_frontend.ViewModels
{
    public class GeneralView
    {
        public int AllAgents {  get; set; }
        public int InActiveAgents {  get; set; }
        public int AllTargets { get; set; }
        public int EliminatedTargets { get; set; }
        public int AllMissions { get; set; }
        public int InProgresMissions {  get; set; }
        public string AgentTargetRatio { get { return $"{AllAgents} / {AllTargets}"; }  }
        public string ProposalAgentsRatio { get; set; }
        public GeneralView(int agentsNum
            , int activeAgentsNum
            , int targetsNum
            , int eliminatedTargetsNum
            , int missionsNum
            , int inProgresMissionsNum
            , string proposalAgentsRatio
            )
        {
            AllAgents = agentsNum;
            InActiveAgents = activeAgentsNum;
            AllTargets = targetsNum;
            EliminatedTargets = eliminatedTargetsNum;
            AllMissions = missionsNum;
            InProgresMissions = inProgresMissionsNum;
            ProposalAgentsRatio = proposalAgentsRatio;
        }
    }
}
